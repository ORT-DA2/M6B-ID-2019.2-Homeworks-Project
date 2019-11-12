import { Exercise } from './Exercise';

export class Homework {
  id: string;
  description: string;
  dueDate: Date;
  score: number;
  exercises: Array<Exercise>;

  constructor(description:string, score:number, dueDate:Date, exercises: Array<Exercise>){

      this.description = description;
      this.score = score;
      this.dueDate = dueDate;
      this.exercises = exercises;
  }
}
