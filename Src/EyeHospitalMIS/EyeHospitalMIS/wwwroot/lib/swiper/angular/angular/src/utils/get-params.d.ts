declare type KeyValueType = {
    [x: string]: any;
};
export declare const allowedparams: string[];
export declare function getparams(obj?: any): {
    params: any;
    passedparams: KeyValueType;
    rest: KeyValueType;
};
export {};
