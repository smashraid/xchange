import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

import { Currency } from './currency';
import { ConvertResponse } from './convert-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConvertService {
  private url: string = "http://localhost:5000/api/values";
  
  constructor(private http: HttpClient) { }

  getCurrencyAmount(currency: Currency): Observable<ConvertResponse> {
    const httpOptions = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + localStorage.getItem('API_TOKEN')
        })
    };
    return this.http.get<ConvertResponse>(`${this.url}/${currency.From}/${currency.To}`, httpOptions);
  }
}
