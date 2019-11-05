import { HomeworksService } from './../services/homeworks.service';
import { Component, OnInit } from '@angular/core';
import { Homework } from '../models/Homework';
import { Exercise } from '../models/Exercise';

const ELEMENT_DATA = [
  new Homework("Una tarea", 1, new Date(), [new Exercise("1", "Un Problema", 0)]),
  new Homework("Otra tarea", 4, new Date(), [])
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
  pageTitle: string;

  constructor(private _serviceHomeworks:HomeworksService) { }

  ngOnInit() {
    this.dataSource = this._serviceHomeworks.getHomeworks();
    this._serviceHomeworks.getHomeworksAPI().subscribe(
      ((data : Array<Homework>) => this.result(data)),
      ((error : any) => console.log(error))
  )
  }
  private result(data: Array<Homework>):void {
    this.dataSource = data;
    console.log(this.dataSource);
  }
  onoffChange(): void {
    this.onoff = !this.onoff;
  }

  onRatingClicked(message:string):void {
    this.pageTitle = message;
}

}
