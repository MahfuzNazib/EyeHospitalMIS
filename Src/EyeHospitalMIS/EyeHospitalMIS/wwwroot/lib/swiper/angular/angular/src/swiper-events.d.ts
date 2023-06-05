import { SwiperEvents } from 'swiper/types';
export declare type Eventsparams<T = SwiperEvents> = {
    [P in keyof T]: T[P] extends (...args: any[]) => any ? parameters<T[P]> : never;
};
