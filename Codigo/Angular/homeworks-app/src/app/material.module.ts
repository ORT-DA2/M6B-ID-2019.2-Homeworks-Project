import { NgModule } from '@angular/core';

import {
  MatListModule,
  MatInputModule,
  MatTableModule,
  MatSlideToggleModule,
  MatCardModule,
  MatMenuModule,
  MatFormFieldModule,
  MatButtonModule,
  MatDatepickerModule,
  MatNativeDateModule
} from '@angular/material';

@NgModule({
  exports: [
    MatListModule,
    MatInputModule,
    MatTableModule,
    MatSlideToggleModule,
    MatCardModule,
    MatMenuModule,
    MatFormFieldModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule
  ]
})
export class MaterialComponentsModule {}
