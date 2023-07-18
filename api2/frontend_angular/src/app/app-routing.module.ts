import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DataEnergyComponent } from './data-energy/data-energy.component';

const routes: Routes = [
    { path: '', component: DataEnergyComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
