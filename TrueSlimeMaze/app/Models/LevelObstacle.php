<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class LevelObstacle extends Model
{
    protected $fillable = [
        'crossable',
        'effect',
        'name',
        'image',
        'minimum_number',
        'maximum_number'
    ];
}
