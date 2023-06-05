export default function effectTarget(effectparams, $slideEl) {
  if (effectparams.transformEl) {
    return $slideEl.find(effectparams.transformEl).css({
      'backface-visibility': 'hidden',
      '-webkit-backface-visibility': 'hidden'
    });
  }

  return $slideEl;
}