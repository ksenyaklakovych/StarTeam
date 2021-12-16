import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigService } from 'src/app/services/config.service';
import { Config } from 'src/app/types/Config';

@Injectable()
export class QuestionsService {
    apiUrl: string = "api/questions";

    constructor(private http: HttpClient) {
    }

    getQuestions(): Observable<Question[]> {
        return this.http.get<Question[]>(`https://localhost:5001/${this.apiUrl}/questions`);
    }
}

export interface Question {
    title: string;
    description: string;
    authorName: string;
    createdDate: Date;
}