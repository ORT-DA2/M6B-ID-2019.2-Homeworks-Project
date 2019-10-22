import { HomeworksService } from './../services/homeworks.service';
import { Component, OnInit } from '@angular/core';
import { Homework } from '../models/Homework';
import { Exercise } from '../models/Exercise';

const ELEMENT_DATA = [
  new Homework("1", "Una tarea", 0, new Date(), [new Exercise("1", "Un Problema", 0)]),
  new Homework("2", "Otra tarea", 0, new Date(), [])
];

@Component({
  selector: 'app-homework-list',
  templateUrl: './homework-list.component.html',
  styleUrls: ['./homework-list.component.css']
})
export class HomeworkListComponent implements OnInit {

  displayedColumns: string[] = ['id', 'description', 'duedate', 'score'];
  dataSource = ELEMENT_DATA;
  listFilter: string = "";
  onoff: boolean = false;

  constructor(private _serviceHomeworks:HomeworksService) { }

  ngOnInit() {
    this.dataSource = this._serviceHomeworks.getHomeworks();
  }

  onoffChange(): void {
    this.onoff = !this.onoff;
  }

}
