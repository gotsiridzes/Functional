type Currency = Currency of string;; // currency object contains string
let usd = Currency("usd");;
type Amount = Amount of decimal * Currency;;

let deposit = Amount(5m, usd);;

type Money = 
    | Cash of decimal * Currency
    | Gift of decimal * Currency * System.DateTime;;

let instrument = Cash(20m, usd);


type Adder = Money * Amount * System.DateTime -> Money * Amount;;