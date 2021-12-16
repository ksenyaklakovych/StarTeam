import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class QuestionsService {
    base_url: string = "assets";

    constructor(private http: HttpClient) { }

    getQuestions(): Observable<Question[]> {
        return this.http.get<Question[]>(`${this.base_url}/questions.json`);
    }
}

export interface Question {
    title: string;
    description: string;
    authorName: string;
    createdDate: Date;
}