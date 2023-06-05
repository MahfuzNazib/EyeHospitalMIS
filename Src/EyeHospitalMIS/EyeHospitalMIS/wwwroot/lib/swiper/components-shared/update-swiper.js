import { isObject, extend } from './utils.js';

function updateSwiper({
  swiper,
  slides,
  passedparams,
  changedparams,
  nextEl,
  prevEl,
  scrollbarEl,
  paginationEl
}) {
  const updateparams = changedparams.filter(key => key !== 'children' && key !== 'direction');
  const {
    params: currentparams,
    pagination,
    navigation,
    scrollbar,
    virtual,
    thumbs
  } = swiper;
  let needThumbsInit;
  let needControllerInit;
  let needPaginationInit;
  let needScrollbarInit;
  let needNavigationInit;

  if (changedparams.includes('thumbs') && passedparams.thumbs && passedparams.thumbs.swiper && currentparams.thumbs && !currentparams.thumbs.swiper) {
    needThumbsInit = true;
  }

  if (changedparams.includes('controller') && passedparams.controller && passedparams.controller.control && currentparams.controller && !currentparams.controller.control) {
    needControllerInit = true;
  }

  if (changedparams.includes('pagination') && passedparams.pagination && (passedparams.pagination.el || paginationEl) && (currentparams.pagination || currentparams.pagination === false) && pagination && !pagination.el) {
    needPaginationInit = true;
  }

  if (changedparams.includes('scrollbar') && passedparams.scrollbar && (passedparams.scrollbar.el || scrollbarEl) && (currentparams.scrollbar || currentparams.scrollbar === false) && scrollbar && !scrollbar.el) {
    needScrollbarInit = true;
  }

  if (changedparams.includes('navigation') && passedparams.navigation && (passedparams.navigation.prevEl || prevEl) && (passedparams.navigation.nextEl || nextEl) && (currentparams.navigation || currentparams.navigation === false) && navigation && !navigation.prevEl && !navigation.nextEl) {
    needNavigationInit = true;
  }

  const destroyModule = mod => {
    if (!swiper[mod]) return;
    swiper[mod].destroy();

    if (mod === 'navigation') {
      currentparams[mod].prevEl = undefined;
      currentparams[mod].nextEl = undefined;
      swiper[mod].prevEl = undefined;
      swiper[mod].nextEl = undefined;
    } else {
      currentparams[mod].el = undefined;
      swiper[mod].el = undefined;
    }
  };

  updateparams.forEach(key => {
    if (isObject(currentparams[key]) && isObject(passedparams[key])) {
      extend(currentparams[key], passedparams[key]);
    } else {
      const newValue = passedparams[key];

      if ((newValue === true || newValue === false) && (key === 'navigation' || key === 'pagination' || key === 'scrollbar')) {
        if (newValue === false) {
          destroyModule(key);
        }
      } else {
        currentparams[key] = passedparams[key];
      }
    }
  });

  if (updateparams.includes('controller') && !needControllerInit && swiper.controller && swiper.controller.control && currentparams.controller && currentparams.controller.control) {
    swiper.controller.control = currentparams.controller.control;
  }

  if (changedparams.includes('children') && slides && virtual && currentparams.virtual.enabled) {
    virtual.slides = slides;
    virtual.update(true);
  } else if (changedparams.includes('children') && swiper.lazy && swiper.params.lazy.enabled) {
    swiper.lazy.load();
  }

  if (needThumbsInit) {
    const initialized = thumbs.init();
    if (initialized) thumbs.update(true);
  }

  if (needControllerInit) {
    swiper.controller.control = currentparams.controller.control;
  }

  if (needPaginationInit) {
    if (paginationEl) currentparams.pagination.el = paginationEl;
    pagination.init();
    pagination.render();
    pagination.update();
  }

  if (needScrollbarInit) {
    if (scrollbarEl) currentparams.scrollbar.el = scrollbarEl;
    scrollbar.init();
    scrollbar.updateSize();
    scrollbar.setTranslate();
  }

  if (needNavigationInit) {
    if (nextEl) currentparams.navigation.nextEl = nextEl;
    if (prevEl) currentparams.navigation.prevEl = prevEl;
    navigation.init();
    navigation.update();
  }

  if (changedparams.includes('allowSlideNext')) {
    swiper.allowSlideNext = passedparams.allowSlideNext;
  }

  if (changedparams.includes('allowSlidePrev')) {
    swiper.allowSlidePrev = passedparams.allowSlidePrev;
  }

  if (changedparams.includes('direction')) {
    swiper.changeDirection(passedparams.direction, false);
  }

  swiper.update();
}

export { updateSwiper };