import { Exercise } from './../models/Exercise';
import { Homework } from './../models/Homework';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomeworksService {

  constructor() { }

  getHomeworks(): Array<Homework> {
    return [
      new Homework('1', 'Una tarea service', 0, new Date(), [
        new Exercise('1', 'Un problema', 1),
        new Exercise('2', 'otro problema', 10)
      ]),
      new Homework('2', 'Otra tarea service', 0, new Date(), [])
    ];
  }
}
