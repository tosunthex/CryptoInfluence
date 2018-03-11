import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {TweetServices} from "../../services/tweet.services";


@Component({
    selector: 'app-tweets',
    templateUrl: './tweets.component.html',
    styleUrls: ['./tweets.component.css'],
    encapsulation: ViewEncapsulation.None
})
export class TweetsComponent implements OnInit {

    socialMediaAnalysisis: any[];

    constructor(private tweetService: TweetServices) {
    }

    ngOnInit() {
        
        this.tweetService.getSocialMediaDetail()
            .subscribe(res => this.socialMediaAnalysisis = res,
                        err =>console.log(err),
                ()=>{
                
                });
    }

}
