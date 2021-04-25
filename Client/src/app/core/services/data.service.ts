import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { ZipCodeViewModel } from 'src/app/models/zip-code-response';
import { CalculatedTaxViewModel } from 'src/app/models/calculated-tax.model';
import { TaxFormViewModel } from 'src/app/models/tax-form.model';

@Injectable({
    providedIn: 'root'
})
export class DataService {
    url = 'https://api.zippopotam.us/us/';
    apiEndpoint = 'http://localhost:52350/api'
    constructor(private http: HttpClient) { }

    getTax(taxRequest: TaxFormViewModel) : Observable<CalculatedTaxViewModel> {
        const headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
        return this.http.post<CalculatedTaxViewModel>(`${this.apiEndpoint}/Tax`, taxRequest, {headers})
            .pipe(
                map(res => res),
                catchError(this.handleError)
            );
    }

    getZipCode(zipCode) {
        const endpoint = `${this.url}${zipCode}`;
        return this.http.get<ZipCodeViewModel>(endpoint).pipe(map(res => res), catchError(this.handleError))
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