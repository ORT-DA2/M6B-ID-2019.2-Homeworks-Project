import { NgModule } from '@angular/core';

import {
  MatListModule,
  MatInputModule,
  MatTableModule,
  MatSlideToggleModule,
  MatCardModule
} from '@angular/material';

@NgModule({
  exports: [
    MatListModule,
    MatInputModule,
    MatTableModule,
    MatSlideToggleModule,
    MatCardModule
  ]
})
export class MaterialComponentsModule {}

