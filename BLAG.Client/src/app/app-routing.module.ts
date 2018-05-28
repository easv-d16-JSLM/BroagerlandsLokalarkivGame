import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AudioComponent }   from './question/audio/audio.component';
import { AnnouncementComponent }   from './question/announcement/announcement.component';
import { ImageComponent }   from './question/image/image.component';
import { VideoComponent }   from './question/video/video.component';
import { TextComponent }   from './question/text/text.component';
import { TextViewComponent }   from './question/text/view/view.component';
import { QuestionnaireComponent }   from './questionnaire/questionnaire/questionnaire.component';
import { AnswerComponent }   from './answer/answer/answer.component';




const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'question/edit', component: TextComponent },
  { path: 'question/view', component: TextComponent },
  { path: 'answer/view', component: AnswerComponent },
  { path: 'answer/edit', component: AnswerComponent },
  { path: 'questionnaire/view', component: QuestionnaireComponent },
  { path: 'questionnaire/edit', component: QuestionnaireComponent },

];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
