import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItemsComponent } from './components/items/items.component';
import { RemoveItemComponent } from './components/remove-item/remove-item.component';

const routes: Routes = [
  { path: `remove`, component: RemoveItemComponent},
  { path: `items`, component: ItemsComponent}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})

export class AppRoutingModule { }
