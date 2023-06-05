function _extends() { _extends = Object.assign ? Object.assign.bind() : function (target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i]; for (var key in source) { if (Object.prototype.hasOwnProperty.call(source, key)) { target[key] = source[key]; } } } return target; }; return _extends.apply(this, arguments); }

import React, { useRef, useState, useEffect, forwardRef } from 'react';
import SwiperCore from 'swiper';
import { getparams } from '../components-shared/get-params.js';
import { mountSwiper } from '../components-shared/mount-swiper.js';
import { needsScrollbar, needsNavigation, needsPagination, uniqueClasses, extend } from '../components-shared/utils.js';
import { renderLoop, calcLoopedSlides } from './loop.js';
import { getChangedparams } from '../components-shared/get-changed-params.js';
import { getChildren } from './get-children.js';
import { updateSwiper } from '../components-shared/update-swiper.js';
import { renderVirtual } from './virtual.js';
import { updateOnVirtualData } from '../components-shared/update-on-virtual-data.js';
import { useIsomorphicLayoutEffect } from './use-isomorphic-layout-effect.js';
import { SwiperContext } from './context.js';
const Swiper = /*#__PURE__*/forwardRef(function (_temp, externalElRef) {
  let {
    className,
    tag: Tag = 'div',
    wrapperTag: WrapperTag = 'div',
    children,
    onSwiper,
    ...rest
  } = _temp === void 0 ? {} : _temp;
  let eventsAssigned = false;
  const [containerClasses, setContainerClasses] = useState('swiper');
  const [virtualData, setVirtualData] = useState(null);
  const [breakpointChanged, setBreakpointChanged] = useState(false);
  const initializedRef = useRef(false);
  const swiperElRef = useRef(null);
  const swiperRef = useRef(null);
  const oldPassedparamsRef = useRef(null);
  const oldSlides = useRef(null);
  const nextElRef = useRef(null);
  const prevElRef = useRef(null);
  const paginationElRef = useRef(null);
  const scrollbarElRef = useRef(null);
  const {
    params: swiperparams,
    passedparams,
    rest: restProps,
    events
  } = getparams(rest);
  const {
    slides,
    slots
  } = getChildren(children);

  const onBeforeBreakpoint = () => {
    setBreakpointChanged(!breakpointChanged);
  };

  Object.assign(swiperparams.on, {
    _containerClasses(swiper, classes) {
      setContainerClasses(classes);
    }

  });

  const initSwiper = () => {
    // init swiper
    Object.assign(swiperparams.on, events);
    eventsAssigned = true;
    swiperRef.current = new SwiperCore(swiperparams);

    swiperRef.current.loopCreate = () => {};

    swiperRef.current.loopDestroy = () => {};

    if (swiperparams.loop) {
      swiperRef.current.loopedSlides = calcLoopedSlides(slides, swiperparams);
    }

    if (swiperRef.current.virtual && swiperRef.current.params.virtual.enabled) {
      swiperRef.current.virtual.slides = slides;
      const extendWith = {
        cache: false,
        slides,
        renderExternal: setVirtualData,
        renderExternalUpdate: false
      };
      extend(swiperRef.current.params.virtual, extendWith);
      extend(swiperRef.current.originalparams.virtual, extendWith);
    }
  };

  if (!swiperElRef.current) {
    initSwiper();
  } // Listen for breakpoints change


  if (swiperRef.current) {
    swiperRef.current.on('_beforeBreakpoint', onBeforeBreakpoint);
  }

  const attachEvents = () => {
    if (eventsAssigned || !events || !swiperRef.current) return;
    Object.keys(events).forEach(eventName => {
      swiperRef.current.on(eventName, events[eventName]);
    });
  };

  const detachEvents = () => {
    if (!events || !swiperRef.current) return;
    Object.keys(events).forEach(eventName => {
      swiperRef.current.off(eventName, events[eventName]);
    });
  };

  useEffect(() => {
    return () => {
      if (swiperRef.current) swiperRef.current.off('_beforeBreakpoint', onBeforeBreakpoint);
    };
  }); // set initialized flag

  useEffect(() => {
    if (!initializedRef.current && swiperRef.current) {
      swiperRef.current.emitSlidesClasses();
      initializedRef.current = true;
    }
  }); // mount swiper

  useIsomorphicLayoutEffect(() => {
    if (externalElRef) {
      externalElRef.current = swiperElRef.current;
    }

    if (!swiperElRef.current) return;

    if (swiperRef.current.destroyed) {
      initSwiper();
    }

    mountSwiper({
      el: swiperElRef.current,
      nextEl: nextElRef.current,
      prevEl: prevElRef.current,
      paginationEl: paginationElRef.current,
      scrollbarEl: scrollbarElRef.current,
      swiper: swiperRef.current
    }, swiperparams);
    if (onSwiper) onSwiper(swiperRef.current); // eslint-disable-next-line

    return () => {
      if (swiperRef.current && !swiperRef.current.destroyed) {
        swiperRef.current.destroy(true, false);
      }
    };
  }, []); // watch for params change

  useIsomorphicLayoutEffect(() => {
    attachEvents();
    const changedparams = getChangedparams(passedparams, oldPassedparamsRef.current, slides, oldSlides.current, c => c.key);
    oldPassedparamsRef.current = passedparams;
    oldSlides.current = slides;

    if (changedparams.length && swiperRef.current && !swiperRef.current.destroyed) {
      updateSwiper({
        swiper: swiperRef.current,
        slides,
        passedparams,
        changedparams,
        nextEl: nextElRef.current,
        prevEl: prevElRef.current,
        scrollbarEl: scrollbarElRef.current,
        paginationEl: paginationElRef.current
      });
    }

    return () => {
      detachEvents();
    };
  }); // update on virtual update

  useIsomorphicLayoutEffect(() => {
    updateOnVirtualData(swiperRef.current);
  }, [virtualData]); // bypass swiper instance to slides

  function renderSlides() {
    if (swiperparams.virtual) {
      return renderVirtual(swiperRef.current, slides, virtualData);
    }

    if (!swiperparams.loop || swiperRef.current && swiperRef.current.destroyed) {
      return slides.map(child => {
        return /*#__PURE__*/React.cloneElement(child, {
          swiper: swiperRef.current
        });
      });
    }

    return renderLoop(swiperRef.current, slides, swiperparams);
  }

  return /*#__PURE__*/React.createElement(Tag, _extends({
    ref: swiperElRef,
    className: uniqueClasses(`${containerClasses}${className ? ` ${className}` : ''}`)
  }, restProps), /*#__PURE__*/React.createElement(SwiperContext.Provider, {
    value: swiperRef.current
  }, slots['container-start'], /*#__PURE__*/React.createElement(WrapperTag, {
    className: "swiper-wrapper"
  }, slots['wrapper-start'], renderSlides(), slots['wrapper-end']), needsNavigation(swiperparams) && /*#__PURE__*/React.createElement(React.Fragment, null, /*#__PURE__*/React.createElement("div", {
    ref: prevElRef,
    className: "swiper-button-prev"
  }), /*#__PURE__*/React.createElement("div", {
    ref: nextElRef,
    className: "swiper-button-next"
  })), needsScrollbar(swiperparams) && /*#__PURE__*/React.createElement("div", {
    ref: scrollbarElRef,
    className: "swiper-scrollbar"
  }), needsPagination(swiperparams) && /*#__PURE__*/React.createElement("div", {
    ref: paginationElRef,
    className: "swiper-pagination"
  }), slots['container-end']));
});
Swiper.displayName = 'Swiper';
export { Swiper };