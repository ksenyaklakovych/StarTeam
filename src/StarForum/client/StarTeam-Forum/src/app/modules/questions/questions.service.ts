import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class QuestionsService {
    apiUrl: string = "api/questions";

    constructor(private http: HttpClient) {
    }

    getQuestions(): Observable<Question[]> {
        return this.http.get<Question[]>(`${environment.baseURL}${environment.getAllQuestionsUrl}`);
    }
}

export interface Question {
    title: string;
    description: string;
    authorName: string;
    createdDate: Date;
}