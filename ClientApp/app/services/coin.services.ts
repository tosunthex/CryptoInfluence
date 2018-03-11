import {Injectable} from "@angular/core";
import {Http} from "@angular/http";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";

export class CoinServices {
    private readonly EndPoint = "api/Coin";

    constructor(private http:Http){}

    getCoinDetail(){
        return this.http.get(this.EndPoint)
                        .map(res=> res.json())
                        .catch(this.handlerError)
    }

    private handlerError(error:any):Promise<any> {
        console.error("An Error Occured",error);
        return Promise.reject(error.message||error);
    }
    
}