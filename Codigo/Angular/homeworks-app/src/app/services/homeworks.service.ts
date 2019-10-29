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

  private WEB_API_URL : string = 'http://localhost:5000/api/homeworks';

  constructor(private _httpService: HttpClient) {  }

  getHomeworks(): Array<Homework> {
    return [
      new Homework('1', 'Una tarea service', 3, new Date(), [
        new Exercise('1', 'Un problema', 1),
        new Exercise('2', 'otro problema', 10)
      ]),
      new Homework('2', 'Otra tarea service', 1, new Date(), [])
    ];
  }

  getHomeworksAPI(): Observable<Array<Homework>> {
    const myHeaders = new HttpHeaders();
    myHeaders.append('Accept', 'application/json');
    const httpOptions = {
        headers: myHeaders
    };

    return this._httpService.get<Array<Homework>>(this.WEB_API_URL, httpOptions)
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
