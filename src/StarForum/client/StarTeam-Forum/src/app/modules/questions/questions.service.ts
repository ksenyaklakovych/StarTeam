import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class QuestionsService {
    apiUrl: string = "api/questions";

    constructor(private http: HttpClient) {
    }

    getQuestionById(id: number): Observable<Question> {
        return this.http.get<Question>(`${environment.baseURL}${environment.getQuestionByIdUrl}/${id}`);
    }

    getQuestionsByTagName(tag: string): Observable<Question[]> {
        return this.http.get<Question[]>(`${environment.baseURL}${environment.getQuestionsByTagUrl}/${tag}`);
    }

    getQuestions(requestViewModel: IQuestionRequest): Observable<Question[]> {
        const params: any = requestViewModel;
        return this.http.get<Question[]>(`${environment.baseURL}${environment.getAllQuestionsUrl}`,
        {
            params: params,
        });
    }

    filterTags(filter: string): Observable<Tag[]> {
        return this.http.get<Tag[]>(`${environment.baseURL}${environment.filterTagsUrl}/${filter}`);
    }

    addQuestion(request: any): Observable<string> {
        return this.http.post<string>(`${environment.baseURL}${environment.createQuestionUrl}`, request);
    }
}

export interface Question {
    id: number;
    title: string;
    tags: string[];
    description: string;
    authorName: string;
    createdDate: Date;
}

export interface IQuestionRequest {
    orderOption?: string;
    tags?: string;
}

export interface Tag {
    name: string;
    questionCount: number;
}