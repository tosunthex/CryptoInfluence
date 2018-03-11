import {Injectable} from "@angular/core";
import {Http} from "@angular/http";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";

@Injectable()
export class TweetServices {
    private readonly EndPoint = "api/SocialMediaAnalysis";
    
    constructor(private http:Http){}
    
    getSocialMediaDetail(){
        return this.http.get(this.EndPoint)
                        .map(res => res.json())
                        .catch(this.handlerError);
    }

    private handlerError(error:any):Promise<any> {
        console.error("An Error Occured",error);
        return Promise.reject(error.message||error);
    }
}