package com.example.bjj_android.components

import android.graphics.drawable.Icon
import androidx.annotation.ColorRes
import androidx.annotation.DrawableRes
import androidx.compose.foundation.BorderStroke
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material.Icon
import androidx.compose.material.Surface
import androidx.compose.material.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.res.dimensionResource
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import com.example.bjj_android.R

@Composable
fun Badge(
    text: String,
    @ColorRes color: Int,
    onClick: () -> Unit = {},
    @DrawableRes icon: Int? = null
) {
    // Primary color that has been passed into the component constructor.
    val primaryColor = colorResource(id = color)

    Surface(
        shape = RoundedCornerShape(dimensionResource(id = R.dimen.badge_default_radius)),
        border = BorderStroke(width = 1.dp, color = primaryColor),
        elevation = 8.dp,
    ) {
        Row(
            modifier = Modifier
                .padding(4.dp)
                .clickable { onClick() }
        ) {
            // Display icon if a bitmap is provided.
            icon?.let {
                val iconPainter = painterResource(id = it)
                androidx.compose.material.Icon(painter = iconPainter, contentDescription = "Badge Icon $it")
            }
            Text(text = text, color = primaryColor)
        }
    }
}

/**
 * Mainly used to preview the badge component.
 */
@Preview
@Composable
private fun BadgePreview() {
    Badge(text = "Testing", color = R.color.teal_200)
}
