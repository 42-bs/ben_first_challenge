import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DataEnergyComponent } from './data-energy/data-energy.component';

const routes: Routes = [
    { path: 'data-energy', component: DataEnergyComponent },
    { path: '', redirectTo: '/data-energy', pathMatch: 'full' },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
