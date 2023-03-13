import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddItemComponent } from './components/add-item/add-item.component';
import { HomeComponent } from './components/home/home.component';
import { ItemDetailsComponent } from './components/item-details/item-details.component';
import { ItemsComponent } from './components/items/items.component';
import { RemoveItemComponent } from './components/remove-item/remove-item.component';

const routes: Routes = [
  { path: `remove`, component: RemoveItemComponent },
  { path: `items`, component: ItemsComponent },
  { path: `home`, component: HomeComponent },
  { path: 'detail/:id', component: ItemDetailsComponent },
  { path: `additem`, component: AddItemComponent },
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})

export class AppRoutingModule { }
