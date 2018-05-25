import { Injectable, Inject } from '@angular/core';  
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Http, Response } from '@angular/http';  
import { Observable, of } from 'rxjs';  
import { Router } from '@angular/router';  
import { map, catchError, tap } from 'rxjs/operators';
import { Text } from '../question/text/text';
import 'rxjs/add/operator/catchError';  
import 'rxjs/add/observable/throw';  
import 'rxjs/add/operator/map'
  
@Injectable()  
export class APIService {  
    myAppUrl: string = "";  
  
    constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {  
        this.myAppUrl = baseUrl;  
    }  


    //Answer Map
    getAnswerMap() {  
        return this._http.get(this.myAppUrl + 'api/AnswerMap')  
            .pipe(map((response: Response) => response.json()))    
            .pipe(catchError(this.errorHandler));  
    }

    getAnswerMapById(id: number) {  
        return this._http.get(this.myAppUrl + 'api/AnswerMap/' + id)  
            .pipe(map((response: Response) => response.json()))   
            .pipe(catchError(this.errorHandler));  
    }

    postAnswerMap(Answer) {  
        return this._http.post(this.myAppUrl + 'api/AnswerMap', Answer)  
            .pipe(map((response: Response) => response.json()))   
            .pipe(catchError(this.errorHandler));  
    }

    updateAnswerMapById(id: number, Answer) {  
        return this._http.put(this.myAppUrl + 'api/AnswerMap/' + id, Answer)  
            .pipe(map((response: Response) => response.json()))    
            .pipe(catchError(this.errorHandler));  
    }

    deleteAnswerMapById(id: number) {  
        return this._http.delete(this.myAppUrl + 'api/ApiWithActions/' + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler));  
    }
    //Answers
    getAnswers() {  
        return this._http.get(this.myAppUrl + 'api/AnswerNumber')  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 
  
    getAnswerById(id: number) {  
        return this._http.get(this.myAppUrl + 'api/AnswerNumber/' + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }  
  
    postAnswer(Answer) {  
        return this._http.post(this.myAppUrl + 'api/AnswerNumber', Answer)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }  

    putAnswerById(id: number, Answer) {  
        return this._http.put(this.myAppUrl + 'api/AnswerNumber/' + id, Answer)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }

    deleteAnswerById(id: number) {  
        return this._http.delete(this.myAppUrl + 'api/AnswerNumber/' + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }  
    //Picture Answer
    getPictureAnswerById(id: number) {  
        return this._http.get(this.myAppUrl + 'api/AnswerPicture/' + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }  
    
    postPictureAnswer(Answer) {  
        return this._http.post(this.myAppUrl + 'api/AnswerPicture', Answer)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }

    insertPictureAnswerById(id: number, Answer) {  
        return this._http.put(this.myAppUrl + 'api/AnswerPicture' + id, Answer)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }


    deletePictureAnswerById(id: number) {  
        return this._http.delete(this.myAppUrl + 'api/ApiWithActions/' + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 
    //Text Answer

    //getTextAnswerById(id: number) {  
    //    return this._http.get(this.myAppUrl + 'api/AnswerTextChoice/' + id)  
    //        .pipe(map((response: Response) => response.json()))  
    //        .pipe(catchError(this.errorHandler))  
    //} 

    //postTextAnswer(Answer) {  
    //    return this._http.post(this.myAppUrl + 'api/AnswerTextChoice', Answer)  
    //        .pipe(map((response: Response) => response.json()))  
    //        .pipe(catchError(this.errorHandler))  
    //}

    //putTextAnswerById(id: number, Answer) {  
    //    return this._http.put(this.myAppUrl + 'api/AnswerTextChoice/' + id, Answer)  
    //        .pipe(map((response: Response) => response.json()))  
    //        .pipe(catchError(this.errorHandler))  
    //}

    //deleteTextAnswerById(id: number) {  
    //    return this._http.delete(this.myAppUrl + 'api/ApiWithActions/' + id)  
    //        .pipe(map((response: Response) => response.json()))  
    //        .pipe(catchError(this.errorHandler))  
    //}

    getTextAnswerById(id: number): Observable<Text> {
        
        return this._http.get<Text>('api/AnswerTextChoice/' + id)
            .pipe(catchError(this.errorHandler));
    }

    postTextAnswer (text: Text): Observable<Text> {
        return this._http.post<Text>('api/AnswerTextChoice/', text)
            .pipe(catchError(this.errorHandler));
    }

    updateTextAnswer (text: Text): Observable<any> {
        return this._http.put('api/AnswerTextChoice/', text)
            .pipe(catchError(this.errorHandler));
    }

    deleteTextAnswerById (id: number): Observable<Text> {     
        return this._http.delete<Text>('api/ApiWithActions/' + id)
            .pipe(catchError(this.errorHandler));
    }
 
    //Announcments
    getQuestionAnnouncment() {  
        return this._http.get(this.myAppUrl + 'api/QuestionAnnouncement')  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }  

    getQuestionAnnouncmentById(id: number) {  
        return this._http.get(this.myAppUrl + 'api/QuestionAnnouncement/' + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 

    postQuestionAnnouncment(QuestionAnnouncement) {  
        return this._http.post(this.myAppUrl + 'api/QuestionAnnouncement/', QuestionAnnouncement)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 

    updateQuestionAnnouncment(id: number, QuestionAnnouncement) {  
        return this._http.put(this.myAppUrl + 'api/QuestionAnnouncement/' + id, QuestionAnnouncement)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }

    deleteQuestionAnnouncment(id: number) {  
        return this._http.delete(this.myAppUrl + 'api/ApiWithActions/' + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 

    //Audio Question
    getAudioQuestions() {  
        return this._http.get(this.myAppUrl + 'api/QuestionAudio')  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }  

    getAudioQuestionById(id: number) {  
        return this._http.get(this.myAppUrl + 'api/QuestionAudio/' + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 

    postAudioQuestion(AudioQuestion) {  
        return this._http.post(this.myAppUrl + 'api/QuestionAudio/', AudioQuestion)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 

    updateAudioQuestion(id: number, AudioQuestion) {  
        return this._http.put(this.myAppUrl + 'api/QuestionAudio/' + id, AudioQuestion)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 

    deleteAudioQuestion(id: number) {  
        return this._http.delete(this.myAppUrl + 'api/ApiWithActions/' + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 
    //Image Question
    getImageQuestions() {  
        return this._http.get(this.myAppUrl + 'api/QuestionImage')  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }  

    getImageQuestionById(id: number) {  
        return this._http.get(this.myAppUrl + 'api/QuestionImage/' + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 

    postImageQuestion(ImageQuestion) {  
        return this._http.post(this.myAppUrl + 'api/QuestionImage/', ImageQuestion)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 

    updateImageQuestion(id: number, ImageQuestion) {  
        return this._http.put(this.myAppUrl + 'api/QuestionImage/' + id, ImageQuestion)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 

    deleteImageQuestion(id: number) {  
        return this._http.delete(this.myAppUrl + 'api/ApiWithActions/' + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 
    //Text Question
    getTextQuestions() {  
        return this._http.get(this.myAppUrl + 'api/QuestionText')  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }  
    
    //getTextQuestionById(id: number) {  
    //    return this._http.get(this.myAppUrl + 'api/QuestionText/' + id)  
    //        .pipe(map((response: Response) => response.json()))  
    //        .pipe(catchError(this.errorHandler))  
    //} 
    
    //postTextQuestion(TextQuestion) {  
    //    return this._http.post(this.myAppUrl + 'api/QuestionText/', TextQuestion)  
    //        .pipe(map((response: Response) => response.json()))  
    //        .pipe(catchError(this.errorHandler))  
    //} 
    
    //updateTextQuestion(id: number, TextQuestion) {  
    //    return this._http.put(this.myAppUrl + 'api/QuestionText/' + id, TextQuestion)  
    //        .pipe(map((response: Response) => response.json()))  
    //        .pipe(catchError(this.errorHandler))  
    //} 
    
    //deleteTextQuestion(id: number) {  
    //    return this._http.delete(this.myAppUrl + 'api/ApiWithActions/' + id)  
    //        .pipe(map((response: Response) => response.json()))  
    //        .pipe(catchError(this.errorHandler))  
    //} 

    getTextQuestionById(id: number): Observable<Text> {
        
        return this._http.get<Text>('api/QuestionText/' + id)
            .pipe(catchError(this.errorHandler));
    }

    postTextQuestion (text: Text): Observable<Text> {
        return this._http.post<Text>('api/QuestionText/', text)
            .pipe(catchError(this.errorHandler));
    }

    updateTextQuestion (text: Text): Observable<any> {
        return this._http.put('api/QuestionText/', text)
            .pipe(catchError(this.errorHandler));
    }

    deleteTextQuestionById (id: number): Observable<Text> {     
        return this._http.delete<Text>('api/ApiWithActions/' + id)
            .pipe(catchError(this.errorHandler));
    }


    //Video Question
    getVideoQuestions() {  
        return this._http.get(this.myAppUrl + 'api/QuestionVideo')  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    }  
    
    getVideoQuestionById(id: number) {  
        return this._http.get(this.myAppUrl + 'api/QuestionVideo/' + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 
    
    postVideoQuestion(VideoQuestion) {  
        return this._http.post(this.myAppUrl + 'api/QuestionVideo/', VideoQuestion)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 
    
    updateVideoQuestion(id: number, VideoQuestion) {  
        return this._http.put(this.myAppUrl + 'api/QuestionVideo/' + id, VideoQuestion)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
    } 
    
    deleteVideoQuestion(id: number) {  
        return this._http.delete(this.myAppUrl + 'api/ApiWithActions/' + id)  
            .pipe(map((response: Response) => response.json()))  
            .pipe(catchError(this.errorHandler))  
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