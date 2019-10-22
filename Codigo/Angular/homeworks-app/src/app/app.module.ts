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

@NgModule({
  declarations: [
    AppComponent,
    CompEjemploComponent,
    HomeworkListComponent,
    HomeworksFilterPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialComponentsModule,
    FormsModule
  ],
  providers: [HomeworksService],
  bootstrap: [AppComponent]
})
export class AppModule { }
