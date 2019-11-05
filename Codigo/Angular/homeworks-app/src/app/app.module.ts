import { HomeworkDetailGuard } from './homework-detail.guard';
import { HomeworksService } from './services/homeworks.service';
import { MaterialComponentsModule } from './material.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CompEjemploComponent } from './comp-ejemplo/comp-ejemplo.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HomeworkListComponent } from './homework-list/homework-list.component';
import { FormsModule } from '@angular/forms';
import { HomeworksFilterPipe } from './homework-list/homeworks-filter.pipe';
import { StarComponent } from './star/star.component';
import { HomeworkDetailComponent } from './homework-detail/homework-detail.component';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NewHomeworkComponent } from './new-homework/new-homework.component';
import { AuthInterceptorService } from './auth-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    CompEjemploComponent,
    HomeworkListComponent,
    HomeworksFilterPipe,
    StarComponent,
    HomeworkDetailComponent,
    NewHomeworkComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialComponentsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [HomeworksService, HomeworkDetailGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
