import { Injectable, Inject } from '@angular/core';  
import { Http, Response } from '@angular/http';  
import { Observable } from 'rxjs';  
import { Router } from '@angular/router';  
import { map, catchError } from 'rxjs/operators';
import 'rxjs/add/operator/catchError';  
import 'rxjs/add/observable/throw';  
import 'rxjs/add/operator/map'
  
@Injectable()  
export class QuestionService {  
    myAppUrl: string = "";  
  
    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {  
        this.myAppUrl = baseUrl;  
    }  
  
    getQuestionList() {  
        return this._http.get(this.myAppUrl + 'api/Question/GetQuestionList')  
            .pipe(map(res => res.json()))  
            .pipe(catchError(this.errorHandler));  
    }  

    getAnswerMap() {  
        return this._http.get(this.myAppUrl + 'api/AnswerMap')  
            .pipe(map(res => res.json()))  
            .pipe(catchError(this.errorHandler));  
    }

    getAnswerMapById(id: number) {  
        return this._http.get(this.myAppUrl + 'api/AnswerMap/' + id)  
            .pipe(map(res => res.json()))  
            .pipe(catchError(this.errorHandler));  
    }
  
    getQuestions() {  
        return this._http.get(this.myAppUrl + 'api/Question/Index')  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler));  
    }  
  
    getQuestionById(id: number) {  
        return this._http.get(this.myAppUrl + "api/Question/Details/" + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }  
  
    saveQuestion(Questions) {  
        return this._http.post(this.myAppUrl + 'api/Question/Create', Questions)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }  
  
    updateQuestion(Questions) {  
        return this._http.put(this.myAppUrl + 'api/Question/Edit', Questions)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler));  
    }  
  
    deleteQuestion(id) {  
        return this._http.delete(this.myAppUrl + "api/ApiWithActions/5" + id)  
            .pipe(map((response: Response) => response.json())) 
            .pipe(catchError(this.errorHandler));  
    }  
  
    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }  
}