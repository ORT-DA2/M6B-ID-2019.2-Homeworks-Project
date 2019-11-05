import { Exercise } from './../models/Exercise';
import { Homework } from './../models/Homework';
import { Component, OnInit } from '@angular/core';
import { HomeworksService } from './../services/homeworks.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-homework',
  templateUrl: './new-homework.component.html',
  styleUrls: ['./new-homework.component.css']
})
export class NewHomeworkComponent implements OnInit {

  constructor(private _serviceHomeworks:HomeworksService, private _router: Router) { }
  description: string = "";
  dueDate: Date;

  ngOnInit() {
  }

  addHomework(): void {
    var hw = new Homework(this.description, 0, this.dueDate, new Array<Exercise>());
    this._serviceHomeworks.postHomeworks(hw).subscribe(
      ((data: String) => this.result(data)),
      ((error: any) => console.log(error))
    )
  }
  private result(data): void {
    console.log(data);
    this._router.navigate(['/homeworks']);
  }
}
