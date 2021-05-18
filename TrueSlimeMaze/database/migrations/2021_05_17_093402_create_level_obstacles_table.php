<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateLevelObstaclesTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('level_obstacles', function (Blueprint $table) {
            $table->id();
            $table->boolean('crossable');
            $table->string('effect');
            $table->string('name');        
            //$table->binary('image');
            $table->integer('minimum_number');
            $table->integer('maximum_number');
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('level_obstacles');
    }
}
