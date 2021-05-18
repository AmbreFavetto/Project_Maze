<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\LevelObstacle;

class LevelObstacleController extends Controller
{
// CRUD CREATE
    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {
        // Validate data
        $request->validate([
            'crossable' => 'required',
            'effect' => 'required',
            'name' => 'required',
            'minimum_number' => 'required',
            'maximum_number' => 'required'
        ]);

        // CREATE
        return LevelObstacle::create($request->all());
    }

// CRUD READ ALL
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        // READ ALL
        return LevelObstacle::all();
    }

// CRUD READ ONE
    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        // READ ONE
        return LevelObstacle::find($id);

        // $levelObstacle = LevelObstacle::find($id);
        // return $levelObstacle->maze_data;
    }

// CRUD UPDATE
    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {
        // UPDATE
        $levelObstacle = LevelObstacle::find($id);
        $levelObstacle->update($request->all());
        return $levelObstacle;
    }

// CRUD DELETE
    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {
        // DELETE
        return LevelObstacle::destroy($id);
    }
}
