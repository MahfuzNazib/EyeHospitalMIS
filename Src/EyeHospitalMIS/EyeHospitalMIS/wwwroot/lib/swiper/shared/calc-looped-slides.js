import Swiper from 'swiper';
export const calcLoopedSlides = (slides, swiperparams) => {
  let slidesPerViewparams = swiperparams.slidesPerView;

  if (swiperparams.breakpoints) {
    const breakpoint = Swiper.prototype.getBreakpoint(swiperparams.breakpoints);
    const breakpointOnlyparams = breakpoint in swiperparams.breakpoints ? swiperparams.breakpoints[breakpoint] : undefined;

    if (breakpointOnlyparams && breakpointOnlyparams.slidesPerView) {
      slidesPerViewparams = breakpointOnlyparams.slidesPerView;
    }
  }

  let loopedSlides = Math.ceil(parseFloat(swiperparams.loopedSlides || slidesPerViewparams, 10));
  loopedSlides += swiperparams.loopAdditionalSlides;

  if (loopedSlides > slides.length && swiperparams.loopedSlidesLimit) {
    loopedSlides = slides.length;
  }

  return loopedSlides;
};