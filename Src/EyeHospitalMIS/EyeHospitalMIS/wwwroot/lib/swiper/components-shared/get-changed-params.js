import { paramsList } from './params-list.js';
import { isObject } from './utils.js';

function getChangedparams(swiperparams, oldparams, children, oldChildren, getKey) {
  const keys = [];
  if (!oldparams) return keys;

  const addKey = key => {
    if (keys.indexOf(key) < 0) keys.push(key);
  };

  if (children && oldChildren) {
    const oldChildrenKeys = oldChildren.map(getKey);
    const childrenKeys = children.map(getKey);
    if (oldChildrenKeys.join('') !== childrenKeys.join('')) addKey('children');
    if (oldChildren.length !== children.length) addKey('children');
  }

  const watchparams = paramsList.filter(key => key[0] === '_').map(key => key.replace(/_/, ''));
  watchparams.forEach(key => {
    if (key in swiperparams && key in oldparams) {
      if (isObject(swiperparams[key]) && isObject(oldparams[key])) {
        const newKeys = Object.keys(swiperparams[key]);
        const oldKeys = Object.keys(oldparams[key]);

        if (newKeys.length !== oldKeys.length) {
          addKey(key);
        } else {
          newKeys.forEach(newKey => {
            if (swiperparams[key][newKey] !== oldparams[key][newKey]) {
              addKey(key);
            }
          });
          oldKeys.forEach(oldKey => {
            if (swiperparams[key][oldKey] !== oldparams[key][oldKey]) addKey(key);
          });
        }
      } else if (swiperparams[key] !== oldparams[key]) {
        addKey(key);
      }
    }
  });
  return keys;
}

export { getChangedparams };