<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Models\Level;
use App\Models\LevelObstacle;
use App\Models\LevelTest;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

// Controllers
Route::apiResource('level', 'App\Http\Controllers\LevelController');
Route::apiResource('levelObstacle', 'App\Http\Controllers\LevelObstacleController');
Route::apiResource('levelTest', 'App\Http\Controllers\LevelTestController');

Route::middleware('auth:api')->get('/user', function (Request $request) {
    return $request->user();
});
