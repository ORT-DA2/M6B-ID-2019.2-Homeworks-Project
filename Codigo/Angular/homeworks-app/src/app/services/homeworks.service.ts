import { Exercise } from './../models/Exercise';
import { Homework } from './../models/Homework';
import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { map, tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HomeworksService {

  private WEB_API_URL : string = 'https://localhost:5001/api/';

  constructor(private _httpService: HttpClient) {  }

  getHomeworks(): Array<Homework> {
    return [
      new Homework('Una tarea service', 3, new Date(), [
        new Exercise('1', 'Un problema', 1),
        new Exercise('2', 'otro problema', 10)
      ]),
      new Homework('Otra tarea service', 1, new Date(), [])
    ];
  }

  postHomeworks(hw): Observable<string> {
    const myHeaders = new HttpHeaders();
    myHeaders.append('Accept', 'application/json');
    myHeaders.append('Content-Type', 'application/json-patch+json');
    const httpOptions = {
        headers: myHeaders,
    };
    return this._httpService.post<string>(this.WEB_API_URL+'Homeworks', hw, httpOptions)
        .pipe(
          tap(data => console.log(data)),
          catchError(this.handleError)
        );
  }

  getHomeworksAPI(): Observable<Array<Homework>> {
    const myHeaders = new HttpHeaders();
    myHeaders.append('Accept', 'application/json');
    const httpOptions = {
        headers: myHeaders
    };

    return this._httpService.get<Array<Homework>>(this.WEB_API_URL+'Homeworks', httpOptions)
        .pipe(
            //map((response : Response) => <Array<Homework>> response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError)
        );
  }
  private handleError(error: any) {
    console.error(error);
    return throwError(error.error || error.message);
  }
}
