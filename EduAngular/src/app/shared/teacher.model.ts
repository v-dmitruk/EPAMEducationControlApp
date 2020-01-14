import { Question } from './question.model';
import { Test } from './test.model';
import { Course } from './course.model';
import { Lection } from './lection.model';

export class Teacher {
    TeacherID : number;
    UserID : number;
    Name : string;
    LastName : string;
    Description : string;
    BirthDate : Date;
    CreatedQuestions : Question[];
    CreatedTests : Test[];
    Courses : Course[];
    CreatedLections : Lection[];
}
