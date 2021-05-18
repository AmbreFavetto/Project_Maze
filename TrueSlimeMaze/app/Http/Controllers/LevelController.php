<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Level;

class LevelController extends Controller
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
            'name' => 'required',
            'creator' => 'required',
            'maze_data' => 'required'
        ]);

        // CREATE
        return Level::create($request->all());
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
        return Level::all();
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
        return Level::find($id)->maze_data;
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
        $level = Level::find($id);
        $level->update($request->all());
        return $level;
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
        return Level::destroy($id);
    }
}
