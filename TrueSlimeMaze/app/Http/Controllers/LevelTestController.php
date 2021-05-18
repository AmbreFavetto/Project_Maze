<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\LevelTest;

class LevelTestController extends Controller
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
            'verif_date' => 'required',
            'verif' => 'required'
        ]);

        // CREATE
        return LevelTest::create($request->all());
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
        return LevelTest::all();
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
        return LevelTest::find($id);

        // $levelTest = LevelTest::find($id);
        // return $levelTest->maze_data;
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
        $levelTest = LevelTest::find($id);
        $levelTest->update($request->all());
        return $levelTest;
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
        return LevelTest::destroy($id);
    }
}
