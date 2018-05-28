import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AudioComponent }   from './question/audio/audio.component';
import { AnnouncementComponent }   from './question/announcement/announcement.component';
import { ImageComponent }   from './question/image/image.component';
import { VideoComponent }   from './question/video/video.component';
import { TextComponent }   from './question/text/text.component';


const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'question/audio', component: AudioComponent },
  { path: 'question/announcement', component: AnnouncementComponent },
  { path: 'question/image', component: ImageComponent },
  { path: 'question/video', component: VideoComponent },
  { path: 'question/text', component: TextComponent },

];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
