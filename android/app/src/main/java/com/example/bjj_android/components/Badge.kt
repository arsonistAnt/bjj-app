package com.example.bjj_android.components

import android.graphics.drawable.Drawable
import android.graphics.drawable.Icon
import androidx.annotation.ColorInt
import androidx.annotation.DrawableRes
import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.Row
import androidx.compose.material.Icon
import androidx.compose.material.Surface
import androidx.compose.material.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.graphics.ImageBitmap
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.tooling.preview.Preview
import com.example.bjj_android.R

@Composable
fun Badge(text : String, @ColorInt color : Int, @DrawableRes icon : Int? = null){
    Row {
        // Display icon if a bitmap is provided.
        icon?.let {
            val iconPainter = painterResource(id = it)
            androidx.compose.material.Icon(painter = iconPainter, contentDescription = "Badge Icon $it" )
        }
        Text(text = text)
    }
}

@Preview
@Composable
private fun BadgePreview(){
    // TODO: Fill out preview
}