import { h } from 'vue';
import { calcLoopedSlides } from '../shared/calc-looped-slides.js';

function renderLoop(swiperRef, slides, swiperparams) {
  const modifiedSlides = slides.map((child, index) => {
    if (!child.props) child.props = {};
    child.props.swiperRef = swiperRef;
    child.props['data-swiper-slide-index'] = index;
    return child;
  });

  function duplicateSlide(child, index, position) {
    if (!child.props) child.props = {};
    return h(child.type, { ...child.props,
      key: `${child.key}-duplicate-${index}-${position}`,
      class: `${child.props.className || ''} ${swiperparams.slideDuplicateClass} ${child.props.class || ''}`
    }, child.children);
  }

  if (swiperparams.loopFillGroupWithBlank) {
    const blankSlidesNum = swiperparams.slidesPerGroup - modifiedSlides.length % swiperparams.slidesPerGroup;

    if (blankSlidesNum !== swiperparams.slidesPerGroup) {
      for (let i = 0; i < blankSlidesNum; i += 1) {
        const blankSlide = h('div', {
          class: `${swiperparams.slideClass} ${swiperparams.slideBlankClass}`
        });
        modifiedSlides.push(blankSlide);
      }
    }
  }

  if (swiperparams.slidesPerView === 'auto' && !swiperparams.loopedSlides) {
    swiperparams.loopedSlides = modifiedSlides.length;
  }

  const loopedSlides = calcLoopedSlides(modifiedSlides, swiperparams);
  const prependSlides = [];
  const appendSlides = [];

  for (let i = 0; i < loopedSlides; i += 1) {
    const index = i - Math.floor(i / modifiedSlides.length) * modifiedSlides.length;
    appendSlides.push(duplicateSlide(modifiedSlides[index], i, 'append'));
    prependSlides.unshift(duplicateSlide(modifiedSlides[modifiedSlides.length - index - 1], i, 'prepend'));
  }

  if (swiperRef.value) {
    swiperRef.value.loopedSlides = loopedSlides;
  }

  return [...prependSlides, ...modifiedSlides, ...appendSlides];
}

export { calcLoopedSlides, renderLoop };