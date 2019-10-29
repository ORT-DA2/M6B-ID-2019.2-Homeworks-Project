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

import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    CompEjemploComponent,
    HomeworkListComponent,
    HomeworksFilterPipe,
    StarComponent,
    HomeworkDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialComponentsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [HomeworksService, HomeworkDetailGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
