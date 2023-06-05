import React from 'react';
import { calcLoopedSlides } from '../shared/calc-looped-slides.js';

function renderLoop(swiper, slides, swiperparams) {
  const modifiedSlides = slides.map((child, index) => {
    return /*#__PURE__*/React.cloneElement(child, {
      swiper,
      'data-swiper-slide-index': index
    });
  });

  function duplicateSlide(child, index, position) {
    return /*#__PURE__*/React.cloneElement(child, {
      key: `${child.key}-duplicate-${index}-${position}`,
      className: `${child.props.className || ''} ${swiperparams.slideDuplicateClass}`
    });
  }

  if (swiperparams.loopFillGroupWithBlank) {
    const blankSlidesNum = swiperparams.slidesPerGroup - modifiedSlides.length % swiperparams.slidesPerGroup;

    if (blankSlidesNum !== swiperparams.slidesPerGroup) {
      for (let i = 0; i < blankSlidesNum; i += 1) {
        const blankSlide = /*#__PURE__*/React.createElement("div", {
          className: `${swiperparams.slideClass} ${swiperparams.slideBlankClass}`
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

  if (swiper) {
    swiper.loopedSlides = loopedSlides;
  }

  return [...prependSlides, ...modifiedSlides, ...appendSlides];
}

export { calcLoopedSlides, renderLoop };