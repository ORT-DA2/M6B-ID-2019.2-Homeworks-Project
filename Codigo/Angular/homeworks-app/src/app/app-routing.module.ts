import { HomeworkDetailComponent } from './homework-detail/homework-detail.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeworkListComponent } from './homework-list/homework-list.component';
import { CompEjemploComponent } from './comp-ejemplo/comp-ejemplo.component';
import { HomeworkDetailGuard } from './homework-detail.guard';
import { NewHomeworkComponent } from './new-homework/new-homework.component';

const routes: Routes = [{path: 'homeworks', component: HomeworkListComponent},
                        {path: 'index', component: CompEjemploComponent},
                        {path: 'homeworks/:id', component: HomeworkDetailComponent, canActivate: [HomeworkDetailGuard]},
                        {path: 'newHomework', component: NewHomeworkComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
