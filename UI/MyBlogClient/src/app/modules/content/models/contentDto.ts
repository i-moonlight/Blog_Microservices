import { User } from "src/app/core/models/user"
import { CommentDto } from "./commentDto"
import { LikeDto } from "./LikeDto"

export class ContentDto {
    id!: string
    title!: string
    text!: string
    comments:CommentDto[]=[]
    likes:LikeDto[]=[]
    user!:User
}