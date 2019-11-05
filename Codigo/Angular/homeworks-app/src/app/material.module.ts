import { NgModule } from '@angular/core';

import {
  MatListModule,
  MatInputModule,
  MatTableModule,
  MatSlideToggleModule,
  MatCardModule,
  MatMenuModule
} from '@angular/material';

@NgModule({
  exports: [
    MatListModule,
    MatInputModule,
    MatTableModule,
    MatSlideToggleModule,
    MatCardModule,
    MatMenuModule
  ]
})
export class MaterialComponentsModule {}
