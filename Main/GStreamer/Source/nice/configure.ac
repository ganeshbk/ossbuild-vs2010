
AC_PREREQ(2.59c)

dnl releases only do -Wall, cvs and prerelease does -Werror too
dnl use a three digit version number for releases, and four for cvs/prerelease
AC_INIT(libnice, 0.0.10)
LIBNICE_RELEASE="yes"

AC_CONFIG_SRCDIR([agent/agent.c])
AC_CONFIG_HEADER([config.h])
AM_INIT_AUTOMAKE([-Wall])
AC_CONFIG_FILES([
	Makefile
	agent/Makefile
	stun/Makefile
	stun/tests/Makefile
	stun/tools/Makefile
	socket/Makefile
	nice/Makefile
	nice/nice.pc
	random/Makefile
	gst/Makefile
	docs/Makefile
	docs/reference/Makefile
	docs/reference/libnice/Makefile
	tests/Makefile
	])

# Set the libtool C/A/R version info
#    If the source code was changed, but there were no interface changes:
#      Increment REVISION.
#    If there was a compatible interface change:
#      Increment CURRENT and AGE. Set REVISION to 0
#    If there was an incompatible interface change:
#      Increment CURRENT. Set AGE and REVISION to 0
LIBNICE_CURRENT=6
LIBNICE_REVISION=0
LIBNICE_AGE=6
LIBNICE_LIBVERSION=${LIBNICE_CURRENT}:${LIBNICE_REVISION}:${LIBNICE_AGE}
LIBNICE_LT_LDFLAGS="-version-info ${LIBNICE_LIBVERSION}"
AC_SUBST(LIBNICE_LT_LDFLAGS)


# Checks for programs.

AC_PROG_CC
AC_USE_SYSTEM_EXTENSIONS
AC_PROG_LIBTOOL


# Checks for compiler features

AC_C_RESTRICT
AC_C_VARARRAYS
AC_HEADER_ASSERT
AC_HEADER_STDBOOL
AC_DEFINE([_FORTIFY_SOURCE], [2], [Define to `2' to get GNU/libc warnings.])
AC_DEFINE([NICEAPI_EXPORT], [ ], [Public library function implementation])
AC_CHECK_HEADERS([arpa/inet.h net/in.h ifaddrs.h], \
		      [AC_DEFINE(HAVE_GETIFADDRS, [1], \
		       [Whether getifaddrs() is available on the system])])

LIBNICE_CFLAGS="-Wall"
dnl if asked for, add -Werror if supported
if test "x$LIBNICE_RELEASE" != "xyes"; then
  LIBNICE_CFLAGS="$LIBNICE_CFLAGS -Werror"
fi

AC_SUBST(LIBNICE_CFLAGS)
AC_MSG_NOTICE([set LIBNICE_CFLAGS to $LIBNICE_CFLAGS])

# Checks for libraries.
AC_CHECK_LIB(rt, clock_gettime, [LIBRT="-lrt"], [LIBRT=""])
AC_CHECK_FUNCS([poll])
AC_SUBST(LIBRT)

PKG_CHECK_MODULES(GLIB, [dnl
	glib-2.0 >= 2.10 dnl
	gobject-2.0 >= 2.10 dnl
	gthread-2.0 >= 2.10 dnl
	])

AC_ARG_WITH(gstreamer, 
	AC_HELP_STRING([--with-gstreamer], [use GStreamer]),
	[with_gstreamer=${withval}],
	[with_gstreamer=auto])

AS_IF([test "$with_gstreamer" != no], [
  
	PKG_CHECK_MODULES(GST, [
		gstreamer-0.10 >= 0.10.0
		gstreamer-base-0.10 >= 0.10.0
		],
		[
		with_gstreamer=yes
		GST_MAJORMINOR=0.10
		gstplugindir="\$(libdir)/gstreamer-$GST_MAJORMINOR"
		],
		[
		AS_IF([test "$with_gstreamer" = yes], [
			AC_MSG_ERROR([GStreamer support was requested but GStreamer libraries are not available])
		])

		with_gstreamer=no
		])
])

AC_SUBST(gstplugindir)

AM_CONDITIONAL(WITH_GSTREAMER, test "$with_gstreamer" = yes)

GUPNP_IGD_REQUIRED=0.1.2

AC_ARG_ENABLE([gupnp],
        AC_HELP_STRING([--disable-gupnp], [Disable GUPnP IGD support]),
        [case "${enableval}" in
            yes) WANT_GUPNP=yes ;;
            no)  WANT_GUPNP=no ;;
            *) AC_MSG_ERROR(bad value ${enableval} for --enable-gupnp) ;;
        esac],
        WANT_GUPNP=test)

HAVE_GUPNP=no
if test "x$WANT_GUPNP" != "xno"; then
   PKG_CHECK_MODULES(GUPNP, gupnp-igd-1.0 >= $GUPNP_IGD_REQUIRED,
    [ HAVE_GUPNP=yes ],
    [ HAVE_GUPNP=no ])
fi
if test "x$WANT_GUPNP" = "xyes" && test "x$HAVE_GUPNP" = "xno"; then
   AC_ERROR([Requested GUPnP IGD, but it is not available])
fi

if test "x$HAVE_GUPNP" = "xyes"; then
   AC_DEFINE(HAVE_GUPNP,,[Have the GUPnP IGD library])
fi

AC_SUBST(HAVE_GUPNP)

dnl Test coverage
AC_ARG_ENABLE([coverage],
	[AS_HELP_STRING([--enable-coverage],
		[build for test coverage (default disabled)])],,
	[enable_coverage="no"])
AS_IF([test "${enable_coverage}" != "no"], [
	CFLAGS="${CFLAGS} -g -O0 -fprofile-arcs -ftest-coverage"
	LDFLAGS="-lgcov"
	CCACHE_DISABLE=1
])
AC_SUBST(CCACHE_DISABLE)

# check for gtk-doc
GTK_DOC_CHECK(1.9)
AC_CONFIG_MACRO_DIR(m4)

AC_OUTPUT

