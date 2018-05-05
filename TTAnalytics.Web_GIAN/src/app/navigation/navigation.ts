export const navigation = [
    {
        'id'      : 'applications',
        'title'   : 'Applications',
        'translate': 'NAV.APPLICATIONS',
        'type'    : 'group',
        'children': [
            {
                'id'   : 'dashboard',
                'title': 'dashboard',
                'translate': 'NAV.DASHBOARD.TITLE',
                'type' : 'item',
                'icon' : 'dashboard',
                'url'  : '/dashboard',
                // 'badge': {
                //     'title': 25,
                //     'translate': 'NAV.DASHBOARD.BADGE',
                //     'bg'   : '#F44336',
                //     'fg'   : '#FFFFFF'
                // }
            },
            {
                'id'   : 'tournaments',
                'title': 'tournaments',
                'translate': 'NAV.TOURNAMENTS.TITLE',
                'type' : 'item',
                'icon' : 'event',
                'url'  : '/torunaments',
                // 'badge': {
                //     'title': 25,
                //     'translate': 'NAV.DASHBOARD.BADGE',
                //     'bg'   : '#F44336',
                //     'fg'   : '#FFFFFF'
                // }
            },
            {
                'id'   : 'profile',
                'title': 'profile',
                'translate': 'NAV.PROFILE.TITLE',
                'type' : 'item',
                'icon' : 'person',
                'url'  : '/profile',
                // 'badge': {
                //     'title': 25,
                //     'translate': 'NAV.DASHBOARD.BADGE',
                //     'bg'   : '#F44336',
                //     'fg'   : '#FFFFFF'
                // }
            }
        ]
    }
];
