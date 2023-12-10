import { User } from "src/app/core/models/user"
import { CommentDto } from "./commentDto"
import { LikesDto } from "./likesDto"


export class ContentDto {
    id!: string
    title!: string
    text!: string
    comments:CommentDto[]=[]
    likes:LikesDto[]=[]
    user!:User
    imageUrl!:string
    categoryId!:string
}