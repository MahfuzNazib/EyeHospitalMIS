import { needsNavigation, needsPagination, needsScrollbar } from './utils.js';

function mountSwiper({
  el,
  nextEl,
  prevEl,
  paginationEl,
  scrollbarEl,
  swiper
}, swiperparams) {
  if (needsNavigation(swiperparams) && nextEl && prevEl) {
    swiper.params.navigation.nextEl = nextEl;
    swiper.originalparams.navigation.nextEl = nextEl;
    swiper.params.navigation.prevEl = prevEl;
    swiper.originalparams.navigation.prevEl = prevEl;
  }

  if (needsPagination(swiperparams) && paginationEl) {
    swiper.params.pagination.el = paginationEl;
    swiper.originalparams.pagination.el = paginationEl;
  }

  if (needsScrollbar(swiperparams) && scrollbarEl) {
    swiper.params.scrollbar.el = scrollbarEl;
    swiper.originalparams.scrollbar.el = scrollbarEl;
  }

  swiper.init(el);
}

export { mountSwiper };