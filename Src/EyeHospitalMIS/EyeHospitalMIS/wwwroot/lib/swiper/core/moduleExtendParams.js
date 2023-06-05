import { extend } from '../shared/utils.js';
export default function moduleExtendparams(params, allModulesparams) {
  return function extendparams(obj = {}) {
    const moduleparamName = Object.keys(obj)[0];
    const moduleparams = obj[moduleparamName];

    if (typeof moduleparams !== 'object' || moduleparams === null) {
      extend(allModulesparams, obj);
      return;
    }

    if (['navigation', 'pagination', 'scrollbar'].indexOf(moduleparamName) >= 0 && params[moduleparamName] === true) {
      params[moduleparamName] = {
        auto: true
      };
    }

    if (!(moduleparamName in params && 'enabled' in moduleparams)) {
      extend(allModulesparams, obj);
      return;
    }

    if (params[moduleparamName] === true) {
      params[moduleparamName] = {
        enabled: true
      };
    }

    if (typeof params[moduleparamName] === 'object' && !('enabled' in params[moduleparamName])) {
      params[moduleparamName].enabled = true;
    }

    if (!params[moduleparamName]) params[moduleparamName] = {
      enabled: false
    };
    extend(allModulesparams, obj);
  };
}