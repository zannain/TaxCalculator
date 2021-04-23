import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class DataService {
    url = 'https://api.zippopotam.us/us/';
    constructor(private http: HttpClient) { }

    getMessage() : Observable<string> {
        return this.http.get<string>(this.url)
            .pipe(
                map(res => res['data']),
                catchError(this.handleError)
            );
    }

    getZipCode(zipCode) {
        const endpoint = `${this.url}${zipCode}`;
        return this.http.get(endpoint).pipe(map(res => res), catchError(this.handleError))
    }

    private handleError(error: HttpErrorResponse) {
        console.error('Server error:', error);
        if (error.error instanceof Error) {
            const errMessage = error.error.message;
            return Observable.throw(errMessage);
        }
        return Observable.throw(error || 'Server error');
    }
}