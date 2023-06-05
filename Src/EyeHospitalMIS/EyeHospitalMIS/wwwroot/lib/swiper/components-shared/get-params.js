import Swiper from 'swiper';
import { isObject, extend } from './utils.js';
import { paramsList } from './params-list.js';

function getparams(obj = {}, splitEvents = true) {
  const params = {
    on: {}
  };
  const events = {};
  const passedparams = {};
  extend(params, Swiper.defaults);
  extend(params, Swiper.extendedDefaults);
  params._emitClasses = true;
  params.init = false;
  const rest = {};
  const allowedparams = paramsList.map(key => key.replace(/_/, ''));
  const plainObj = Object.assign({}, obj);
  Object.keys(plainObj).forEach(key => {
    if (typeof obj[key] === 'undefined') return;

    if (allowedparams.indexOf(key) >= 0) {
      if (isObject(obj[key])) {
        params[key] = {};
        passedparams[key] = {};
        extend(params[key], obj[key]);
        extend(passedparams[key], obj[key]);
      } else {
        params[key] = obj[key];
        passedparams[key] = obj[key];
      }
    } else if (key.search(/on[A-Z]/) === 0 && typeof obj[key] === 'function') {
      if (splitEvents) {
        events[`${key[2].toLowerCase()}${key.substr(3)}`] = obj[key];
      } else {
        params.on[`${key[2].toLowerCase()}${key.substr(3)}`] = obj[key];
      }
    } else {
      rest[key] = obj[key];
    }
  });
  ['navigation', 'pagination', 'scrollbar'].forEach(key => {
    if (params[key] === true) params[key] = {};
    if (params[key] === false) delete params[key];
  });
  return {
    params,
    passedparams,
    rest,
    events
  };
}

export { getparams };